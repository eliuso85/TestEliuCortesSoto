using DataAccess;
using DataEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic
{
    public class PropertyData : IPropertyBussiness
    {
        #region Constructor de la interfaz
        public IProperty data { get; set; }

        public PropertyData(IProperty data)
        {
            this.data = data;
        } 
        #endregion

        public async Task<PROPERTY> GetActivo(int pIdProperty)
        {
            return await this.data.GetActivo(pIdProperty);
        }

    }
}
