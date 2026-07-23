namespace BackendApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Precio { get; set; } = "";
        public string Categoria { get; set; } = "";
    }
}