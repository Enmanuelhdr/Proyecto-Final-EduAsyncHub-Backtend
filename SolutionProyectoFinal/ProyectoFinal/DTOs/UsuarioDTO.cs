namespace ProyectoFinal.DTOs
{
    public class UsuarioDTO
    {
        public class RegisterUserRequestDto
        {
            public string Nombre { get; set; }
            public string CorreoElectronico { get; set; }
            public string Contraseña { get; set; }
            public int RolID { get; set; }

        }

        public class LoginUserRequestDto
        {
            public string CorreoElectronico { get; set; }
            public string Contraseña { get; set; }
        }

        public class UpdateUserRequestDto
        {
            public string UsuarioID { get; set; }
            public string Nombre { get; set; }
            public string CorreoElectronico { get; set; }
            public string Contraseña { get; set; }
            public int RolID { get; set; }

        }

        public class UpdateProfileRequestDto
        {
            public string UsuarioID { get; set; }
            public string Nombre { get; set; }
            public string CorreoElectronico { get; set; }
            public string Contraseña { get; set; }
        }

        public class DeleteUserRequestDto
        {
           public string UserId { get; set; }
        }


    }
}
