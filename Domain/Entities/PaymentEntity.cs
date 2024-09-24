using Domain.Enums;
using Domain.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PaymentEntity : BaseEntity<Guid>,ICreated
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? CourseId { get; set; }
        public float Amount { get; set; }
        public string? BankTransactionId {  get; set; }
        public EnumPaymentMethod PaymentMethod { get; set; }
        public DateTime CreatedAt { get; set; }

        ////////////////////////////////////////////
        
        public UserEntity? userEntity { get; set; }
        public CourseEntity? courseEntity { get; set; }
    }
}
