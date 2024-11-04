﻿using AutoMapper;
using ECOMSYSTEM.DataAccess.EntityModel;
using ECOMSYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMSYSTEM.Repository.AutomapperProfiles
{
    public class ItemCartProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductProfile" /> class.
        /// </summary>
        public ItemCartProfile()
        {
            CreateMap<TblItemCart, ItemCartDetails>();
            CreateMap<ItemCartDetails, TblItemCart>();
        }
    }
}
