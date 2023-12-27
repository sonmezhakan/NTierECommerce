using NTierECommerce.Entities.Enums;
using NTierECommerce.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierECommerce.Entities.Base
{
    public abstract class BaseEntity : IEntity<Guid>
    {
        public BaseEntity()
        {
            Status = DataStatus.Inserted;
            CreatedDate=DateTime.Now;
            IsActive = true;

            //todo: cookie oluşturulduktan sonra veriyi oluşturan kullanıcı bilgisi dahil edilecek.

            CreatedComputerName = "tanımsız";
            CreatedIpAddress = "tanımsız";

            UpdatedComputerName = "tanımsız";
            UpdatedIpAddress = "tanımsız";
            MasterId = Guid.NewGuid();

        }
        public int Id { get ; set ; }
        public Guid MasterId { get ; set ; }

        //todo: Created ve Updated ile başlayan propertylerin değerleri veri context'e kaydedilirken doldurulacak.
        public DateTime CreatedDate { get ; set ; }

        public string CreatedComputerName { get ; set ; }
        public string CreatedIpAddress { get ; set ; }
        public DateTime? UpdatedDate { get ; set ; }
        public string UpdatedComputerName { get ; set ; }
        public string UpdatedIpAddress { get ; set ; }
        public DataStatus Status { get ; set ; }
        public bool IsActive { get ; set ; }
    }
}
