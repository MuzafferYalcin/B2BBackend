﻿namespace Domain.Entities
{
    public class UserOperationClaim
    {
        public int Id { get; set; }
        public int OperationClaimId { get; set; }
        public int UserId { get; set; }
    }
}
