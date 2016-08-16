using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CZBK.ItcastOA.Common
{
    public class MyRequiredAttributeAdapter : System.Web.Mvc.RequiredAttributeAdapter
    {
        public MyRequiredAttributeAdapter(ModelMetadata metadata, ControllerContext context, System.ComponentModel.DataAnnotations.RequiredAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<System.Web.Mvc.ModelClientValidationRule> GetClientValidationRules()
        {
            string errorMessage = string.Format("{0} 不能为空", Metadata.DisplayName);
            return new[] { new ModelClientValidationRequiredRule(errorMessage) };
        }
    }
}
