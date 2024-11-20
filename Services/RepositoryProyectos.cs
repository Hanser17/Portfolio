using Portafolio.Interfaces;
using Portafolio.Models;

namespace Portafolio.Services
{
    public class RepositoryProyectos: IRepositoryProyecto
    {
        public List<ProyectosModels> ObtenerProyecto()
        {
            return new List<ProyectosModels>() { new ProyectosModels
            {

            Titulo = "MedicalAppointmentApp",
            Descripcion = "App creada en C# con Entity Framework que gestiona usuarion y citas medicas",
            Link = "https://github.com/Hanser17/MedicalAPP",
            ImagenURL= "/Imagenes/Medicalapplogo.png"

            },


            };
        }

    }
}
