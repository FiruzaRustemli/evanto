﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Evanto.BL.DTOs.Core;
using Evanto.DAL.Context;

namespace Evanto.BL.Mapping.Profiles.Core
{
    public class CouponProfile: Profile
    {
        public CouponProfile()
        {
            CreateMap<CouponType, CouponTypeDto>();
            CreateMap<DiscountCoupon, DiscountCouponDto>();
            CreateMap<DiscountType, DiscountTypeDto>();
            CreateMap<DiscountCouponStatus, DiscountCouponStatusDto>();
        }
    }
}
