﻿namespace ToeicWeb.Server.AuthService.Models
{
    public class RolePermission
    {
        public int RolePermissionID { get; set; }
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
    }
}
