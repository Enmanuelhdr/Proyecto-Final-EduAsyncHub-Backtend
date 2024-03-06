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
            public int UsuarioID { get; set; }
            public string Nombre { get; set; }
            public string CorreoElectronico { get; set; }
            public string Contraseña { get; set; }
            public string pfp { get; set; }
            public string DescripcionBreve { get; set; }
            public string Intereses { get; set; }
            public string Habilidades { get; set; }
            public int RolID { get; set; }

        }

        public class UpdateProfileRequestDto
        {
            public int UsuarioID { get; set; }
            public string Nombre { get; set; }
            public string CorreoElectronico { get; set; }
            public string Contraseña { get; set; }
            public string DescripcionBreve { get; set; }
            public string Intereses { get; set; }
            public string Habilidades { get; set; }
            public IFormFile Foto { get; set; }
        }

        public class DeleteUserRequestDto
        {
           public int UserId { get; set; }
        }


    }
}
