using System.Data;

namespace SIS.Domain.Interfaces
{
    public interface IExporter
    {
        void Export(DataTable dataTable);
    }
}