using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Infrastructure.DealWithFile
{
    public class FtpWeb
    {

        string ftpRemotePath;
        string ftpUserID;
        string ftpPassword;
        string ftpURI;
        string ftpServerIP;

        /// <summary>  
        /// 连接FTP  
        /// </summary>  
        /// <param name="FtpServerIP">FTP连接地址</param>  
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>  
        /// <param name="FtpUserID">用户名</param>  
        /// <param name="FtpPassword">密码</param>  
        public FtpWeb(string FtpServerIP, string FtpUserID, string FtpPassword)
        {
            ftpServerIP = FtpServerIP;
            ftpUserID = FtpUserID;
            ftpPassword = FtpPassword;
            ftpURI = FtpServerIP + "/";
        }
        /// <summary>  
        /// 上传  
        /// </summary>  
        /// <param name="filename"></param>  
        public void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = ftpURI + fileInf.Name;
            FtpWebRequest reqFTP;

            reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
            }
        }
        /// <summary>  
        /// 上传  
        /// </summary>  
        /// <param name="filename"></param>  
        public bool Upload2(string ftpuri, string filename, out string rename)
        {
            bool u_re = true;
            string LocalDateTime = string.Format("{0:00000000}{1:00}{2:00}{3:00}", int.Parse(DateTime.Now.ToString("yyyyMMdd")), int.Parse(DateTime.Now.Hour.ToString()), int.Parse(DateTime.Now.Minute.ToString()), int.Parse(DateTime.Now.Second.ToString()));
            rename = filename.Substring(filename.LastIndexOf('\\') + 1);//.Substring(0, 16) + LocalDateTime + filename.Substring(filename.LastIndexOf('\\') + 17);
            GotoDirectory(ftpuri, true);
            if (FileExist(rename))
            {
                rename = rename.Substring(0, rename.LastIndexOf('.')) + LocalDateTime + rename.Substring(rename.LastIndexOf('.'));
            }
            FileInfo fileInf = new FileInfo(filename);
            string uri = ftpURI + rename;
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            try
            {
                using (FileStream fs = fileInf.OpenRead())
                {
                    using (Stream strm = reqFTP.GetRequestStream())
                    {
                        try
                        {
                            contentLen = fs.Read(buff, 0, buffLength);
                            while (contentLen != 0)
                            {
                                strm.Write(buff, 0, contentLen);
                                contentLen = fs.Read(buff, 0, buffLength);
                            }
                        }
                        catch
                        {
                            u_re = false;
                        }
                        finally
                        {
                            strm.Close();
                            fs.Close();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                u_re = false;
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
            }
            return u_re;
        }

        /// <summary>  
        /// 上传整个目录  
        /// </summary>  
        /// <param name="localDir">要上传的目录的上一级目录</param>  
        /// <param name="ftpPath">FTP路径</param>  
        /// <param name="dirName">要上传的目录名</param>  
        /// <param name="ftpUser">FTP用户名（匿名为空）</param>  
        /// <param name="ftpPassword">FTP登录密码（匿名为空）</param>  
        public bool UploadDirectory(string localDir, string ftpPath, string dirName, out string rename)
        {
            bool ud = true;
            rename = localDir.Substring(localDir.LastIndexOf('\\') + 1);//.Substring(0, 16) + LocalDateTime + filename.Substring(filename.LastIndexOf('\\') + 17);
            try
            {
                string _rename = "";
                string dir = localDir;//+ dirName + @"\"; //获取当前目录（父目录在目录名）  

                // string dir = localDir + dirName + @"\"; //获取当前目录（父目录在目录名）  
                string LocalDateTime = string.Format("{0:00000000}{1:00}{2:00}{3:00}", int.Parse(DateTime.Now.ToString("yyyyMMdd")), int.Parse(DateTime.Now.Hour.ToString()), int.Parse(DateTime.Now.Minute.ToString()), int.Parse(DateTime.Now.Second.ToString()));

                //检测本地目录是否存在  
                if (!Directory.Exists(dir))
                {
                    //Response.Write("本地目录：“" + dir + "” 不存在！<br/>");
                    return true;
                }
                ///GotoDirectory(ftpPath, true);
                GotoDirectory("", true);
                GotoDirectory(ftpPath + "/" + dirName, false);
                //string dd = ftpURI;
                //ftpPath = ftpURI+ dirName;
                //检测FTP的目录路径是否存在  
                if (!DirectoryExist(rename))//!DirectoryExist(rename)!CheckDirectoryExist(ftpURI + dirName + "/", rename)
                {
                    MakeDir(ftpPath + "/" + dirName, rename);//不存在，则创建此文件夹  dirName
                }
                else
                {
                    rename = rename + LocalDateTime;//dirName
                    MakeDir(ftpPath + "/" + dirName, rename);//dirName
                }
                List<List<string>> infos = GetDirDetails(dir); //获取当前目录下的所有文件和文件夹  

                //先上传文件  
                //Response.Write(dir + "下的文件数：" + infos[0].Count.ToString() + "<br/>");  
                for (int i = 0; i < infos[0].Count; i++)
                {
                    Console.WriteLine(infos[0][i]);
                    ud = Upload2(ftpPath + "/" + dirName + "/" + rename, dir + "\\" + infos[0][i], out _rename);
                    if (!ud)
                    {
                        return false;
                    }
                    // ud=Upload2(ftpPath + "/" + dirName + "/" + rename, dir +"\\"+ infos[0][i],out _rename);//dirName// + @"/" + infos[0][i]
                }
                //再处理文件夹  
                //Response.Write(dir + "下的目录数：" + infos[1].Count.ToString() + "<br/>");  
                for (int i = 0; i < infos[1].Count; i++)
                {
                    ud = UploadDirectory(dir + "\\" + infos[1][i], ftpPath + "/" + dirName, rename, out _rename);
                    if (!ud)
                    {
                        return false;
                    }
                    //UploadDirectory(dir+"\\"+ infos[1][i], ftpPath + "/" + dirName , rename,out _rename);//dirName//UploadDirectory(dir+"\\"+ infos[1][i], ftpPath + "/" + dirName + "/" + rename + @"/", infos[1][i])
                    //Response.Write("文件夹【" + dirName + "】上传成功！<br/>");  
                }
            }

            catch (Exception ex)
            {
                ud = false;
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
            }
            return ud;

        }

        /// <summary>  
        /// 获取目录下的详细信息  
        /// </summary>  
        /// <param name="localDir">本机目录</param>  
        /// <returns></returns>  
        private List<List<string>> GetDirDetails(string localDir)
        {
            List<List<string>> infos = new List<List<string>>();
            try
            {
                infos.Add(Directory.GetFiles(localDir).ToList()); //获取当前目录的文件  

                infos.Add(Directory.GetDirectories(localDir).ToList()); //获取当前目录的目录  

                for (int i = 0; i < infos[0].Count; i++)
                {
                    int index = infos[0][i].LastIndexOf(@"\");
                    infos[0][i] = infos[0][i].Substring(index + 1);
                }
                for (int i = 0; i < infos[1].Count; i++)
                {
                    int index = infos[1][i].LastIndexOf(@"\");
                    infos[1][i] = infos[1][i].Substring(index + 1);
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
            }
            return infos;
        }

        /// <summary>  
        /// 下载  
        /// </summary>  
        /// <param name="filePath"></param>  
        /// <param name="fileName"></param>  
        public void Download(string filePath, string ftpUri, string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {
                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(ftpUri));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
            }
        }


        /// <summary>  
        /// 删除文件  
        /// </summary>  
        /// <param name="fileName"></param>  
        public void Delete(string fileName)
        {
            try
            {
                string uri = fileName;
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(uri));

                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;

                string result = string.Empty;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();

                long size = response.ContentLength;

                using (Stream datastream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(datastream))
                    {
                        try
                        {
                            result = sr.ReadToEnd();
                        }
                        catch (Exception ex)
                        {
                            Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
                        }
                        finally
                        {
                            sr.Close();
                            datastream.Close();
                            response.Close();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
            }
        }

        /// <summary>  
        /// 获取当前目录下明细(包含文件和文件夹)  
        /// </summary>  
        /// <returns></returns>  
        public string[] GetFilesDetailList()
        {
            string[] downloadFiles;
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest ftp;
                ftp = (FtpWebRequest)WebRequest.Create(new Uri(ftpURI));
                ftp.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = ftp.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string line = reader.ReadLine();

                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                //libWriteLog.WriteFile.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
                return downloadFiles = null;
            }
        }

        /// <summary>  
        /// 获取当前目录下文件列表(仅文件)  
        /// </summary>  
        /// <returns></returns>  
        public string[] GetFileList(string mask)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(ftpURI));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (mask.Trim() != string.Empty && mask.Trim() != "*.*")
                    {

                        string mask_ = mask.Substring(0, mask.IndexOf("*"));
                        if (line.Substring(0, mask_.Length) == mask_)
                        {
                            result.Append(line);
                            result.Append("\n");
                        }
                    }
                    else
                    {
                        result.Append(line);
                        result.Append("\n");
                    }
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                //libWriteLog.WriteFile.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// 获取当前目录下所有的文件夹列表(仅文件夹)  
        /// </summary>  
        /// <returns></returns>  
        public string[] GetDirectoryList()
        {
            try
            {
                string[] drectory = GetFilesDetailList();
                string m = string.Empty;
                foreach (string str in drectory)
                {
                    int dirPos = str.IndexOf("<DIR>");
                    if (dirPos > 0)
                    {
                        /*判断 Windows 风格*/
                        m += str.Substring(dirPos + 5).Trim() + "\n";
                    }
                    else if (str.Trim().Substring(0, 1).ToUpper() == "D")
                    {
                        /*判断 Unix 风格*/
                        //string dir = str.Substring(54).Trim();
                        string dir = str.Substring(str.LastIndexOf(" ") + 1).Trim();
                        if (dir != "." && dir != "..")
                        {
                            m += dir + "\n";
                        }
                    }
                }

                char[] n = new char[] { '\n' };
                return m.Split(n);
            }
            catch (Exception ex)
            {
                //libWriteLog.WriteFile.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
                return null;
            }
        }

        /// <summary>  
        /// 判断当前目录下指定的子目录是否存在  
        /// </summary>  
        /// <param name="RemoteDirectoryName">指定的目录名</param>  
        public bool DirectoryExist(string RemoteDirectoryName)
        {
            try
            {
                string[] dirList = GetDirectoryList();

                foreach (string str in dirList)
                {
                    if (str.Trim() == RemoteDirectoryName.Trim())
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                //libWriteLog.WriteFile.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
                return false;
            }
        }

        /// <summary>  
        /// 判断当前目录下指定的文件是否存在  
        /// </summary>  
        /// <param name="RemoteFileName">远程文件名</param>  
        public bool FileExist(string RemoteFileName)
        {
            try
            {
                string[] fileList = GetFileList("*.*");
                if (fileList != null)
                {
                    foreach (string str in fileList)
                    {
                        if (str.Trim() == RemoteFileName.Trim())
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else return false;
            }
            catch (Exception ex)
            {
                //libWriteLog.WriteFile.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
                return false;
            }
        }

        /// <summary>  
        /// 创建文件夹  
        /// </summary>  
        /// <param name="dirName"></param>  
        public void MakeDir(string ftppath, string dirName)
        {
            FtpWebRequest reqFTP;
            try
            {
                GotoDirectory(ftppath, true);
                // dirName = name of the directory to create.  
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(ftpURI + dirName));//ftpURI
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
            }
        }
        /// <summary>  
        /// 改名  
        /// </summary>  
        /// <param name="currentFilename"></param>  
        /// <param name="newFilename"></param>  
        public void ReName(string currentFilename, string newFilename)
        {
            FtpWebRequest reqFTP;
            try
            {
                reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(ftpURI + currentFilename));
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();

                ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Log.Error(System.Reflection.MethodBase.GetCurrentMethod().Name + ":    " + ex.ToString());
            }
        }

        /// <summary>  
        /// 切换当前目录  
        /// </summary>  
        /// <param name="DirectoryName"></param>  
        /// <param name="IsRoot">true 绝对路径   false 相对路径</param>  
        public void GotoDirectory(string DirectoryName, bool IsRoot)
        {
            if (IsRoot)
            {
                ftpRemotePath = DirectoryName;
            }
            else
            {
                ftpRemotePath += DirectoryName + "/";
            }
            ftpURI = "ftp://" + ftpServerIP + "/" + ftpRemotePath + "/";
        }
    }
}
