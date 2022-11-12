namespace CadeteriaWeb.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ClienteDTO> ClienteDTOs { get; set; }
        public IEnumerable<CadeteDTO> CadeteDTOs { get; set; }
    }
}
