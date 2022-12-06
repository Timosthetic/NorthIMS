using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeederProject.Models
{
    public class PlcEventModel : BindableBase
    {
        private string _RandomCode;
        public string RandomCode
        {
            get { return _RandomCode; }
            set { SetProperty(ref _RandomCode, value); }
        }
        private short _seqID;
        public short SeqID
        {
            get { return _seqID; }
            set { SetProperty(ref _seqID, value); }
        }
        private string _FName;
        public string FName
        {
            get { return _FName; }
            set { SetProperty(ref _FName, value); }
        }

        private string _FTrayName;
        public string FTrayName
        {
            get { return _FTrayName; }
            set { SetProperty(ref _FTrayName, value); }
        }

        private string _FProductName;
        public string FProductName
        {
            get { return _FProductName; }
            set { SetProperty(ref _FProductName, value); }
        }

        private string _FAddr;
        public string FAddr
        {
            get { return _FAddr; }
            set { SetProperty(ref _FAddr, value); }
        }

        private string _FEvent;
        public string FEvent
        {
            get { return _FEvent; }
            set { SetProperty(ref _FEvent, value); }
        }

        private DateTime _FStartTime=DateTime.Now;
        public DateTime FStartTime
        {
            get { return _FStartTime; }
            set { SetProperty(ref _FStartTime, value); }
        }
        private DateTime _FStartTime1 ;
        public DateTime FStartTime1
        {
            get { return _FStartTime1; }
            set { SetProperty(ref _FStartTime1, value); }
        }
        private double _FDoTime;
        public double FDoTime
        {
            get { return _FDoTime; }
            set { SetProperty(ref _FDoTime, value); }
        }

        private string _FResult;
        public string FResult
        {
            get { return _FResult; }
            set
            {
                SetProperty(ref _FResult, value);
                if (value == "1")
                {
                    //符合要求
                    FResultColor = "Green";
                }
                else
                {
                    //符合要求
                    FResultColor = "Red";
                }
            }
        }

        private string _FResultColor;
        public string FResultColor
        {
            get { return _FResultColor; }
            set { SetProperty(ref _FResultColor, value); }
        }

        private string _FResultMark;
        public string FResultMark
        {
            get { return _FResultMark; }
            set { SetProperty(ref _FResultMark, value); }
        }
    }
}
