
using JP.Exactus.Data;

namespace JP.Exactus.Logic
{
    /// <summary>
    /// Clase base de la cuál heredan todas las clases de lógica.
    /// El Context es asignado cuando se instancia en BusinessCore.
    /// </summary>
    public class BusinessCoreObject
    {
        public LicenciaCoreDBEntities Context { get; set; }
    }
}