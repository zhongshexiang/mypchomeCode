using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPSTAR.System.ViewModel;
using CZBK.ItcastOA.Model;
using AutoMapper;
namespace UPSTAR.System.ModelMapper
{
    public static class ExtensionHelper
    {
        static ExtensionHelper()
        {
            Mapper.CreateMap<LoginViewModel, UserInfo>();
        }

        public static UserInfo UserInfoMap(this LoginViewModel model)
        {
            return Mapper.Map<LoginViewModel, UserInfo>(model);
        }
    }
}
