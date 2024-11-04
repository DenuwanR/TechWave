using AutoMapper;
using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Repository.AutomapperProfiles
{
    public class Orderprofile : Profile
    {
        public Orderprofile()
        {
            CreateMap<TblOrder, OrderDetails>();
            CreateMap<OrderDetails, TblOrder>();
        }
    }
}
