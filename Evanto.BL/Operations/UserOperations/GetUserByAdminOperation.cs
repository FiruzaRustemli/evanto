using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Evanto.BL.DTOs.Admin;
using Evanto.DAL.Context;
using Evanto.Utils;

namespace Evanto.BL.Operations.UserOperations
{
    public class GetUserByAdminOperation : Operation<GetUserInputByAdmin, GetUserOutputByAdmin>
    {
        public override void DoExecute()
        {
            GetUserOutputByAdmin output = new GetUserOutputByAdmin();
            var user = Uow.EvantoContext.SearchUser(Parameters.Id,
                    null,
                    null,
                    null,
                    null,
                    null)
                .FirstOrDefault();

            List<VendorServicePacket> data = new List<VendorServicePacket>();


            output.User = Mapper.Map<User, UserAdminDto>(user);

            if (user?.Vendor != null)
            {
                data = user.Vendor.VendorServicePacket.ToList();
                output.User.VendorName = user.Vendor.Name;
            }
            var predicaterole = PredicateBuilder.True<Role>();
            var roles = Uow.GetRepository<Role>().GetAll(predicaterole).Select(ct => new SelectListItem()
            {
                Text = ct.Name,
                Value = ct.Id.ToString(),
                Selected = (ct.Id == (user.RoleId))

            }).ToList();

            var predicateImage = PredicateBuilder.True<File>();
            predicateImage = predicateImage.And(f => f.RelationalId==Parameters.Id).And(f=>f.ContentTypeId==1).And(f=>f.TypeId==1);

            var imagepath = Uow.GetRepository<File>().GetAll(predicateImage).FirstOrDefault();
            if (imagepath != null)
                output.User.Image= Convert.ToBase64String(System.IO.File.ReadAllBytes(ConfigHelper.GetAppSetting("FileSaveServer") + imagepath.Path)); 

            var predicatetype = PredicateBuilder.True<UserType>();
            var types = Uow.GetRepository<UserType>().GetAll(predicatetype).Select(ct => new SelectListItem()
            {
                Text = ct.Name,
                Value = ct.Id.ToString(),
                Selected = (ct.Id == user.TypeId)

            }).ToList();

            var predicatestatus = PredicateBuilder.True<UserStatus>();
            var statuses = Uow.GetRepository<UserStatus>().GetAll(predicatestatus).Select(ct => new SelectListItem()
            {
                Text = ct.Name,
                Value = ct.Id.ToString(),
                Selected = (ct.Id == user.StatusId)

            }).ToList();

            var predicateGender = PredicateBuilder.True<Gender>();
            var genders = Uow.GetRepository<Gender>().GetAll(predicateGender).Select(ct => new SelectListItem()
            {
                Text = ct.Name,
                Value = ct.Id.ToString(),
                Selected = (ct.Id == user.RoleId)

            }).ToList();

            output.User.Roles = roles;
            output.User.Statuses = statuses;
            output.User.Types = types;
            output.User.Genders = genders;
            output.User.VendorServicePackets = Mapper.Map<List<VendorServicePacket>, List<VendorServicePacketByAdminDto>>(data);
            Result.Output= output;
        }
    }
}
