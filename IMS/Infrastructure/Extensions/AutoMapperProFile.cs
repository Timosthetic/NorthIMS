using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;



namespace Infrastructure.Extensions
{
  public   class AutoMapperProFile:MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {
            //CreateMap<MenuItemTree, MenuItemTreeDto>().ReverseMap();
                //.ForMember(d => d.Id, opt => opt.MapFrom(s => s.mp_Id))
                //.ForMember(d=>d.Title,opt=>opt.MapFrom(s=>s.mp_MenuName))
                //.ForMember(d => d.Order, opt => opt.MapFrom(s => s.mp_Order))
                //.ForMember(d => d.ParentId, opt => opt.MapFrom(s => s.mp_ParentId))
                //.ForMember(d => d.Icon, opt => opt.MapFrom(s => s.mp_Icon));
        }
    }
}
