using System.Net.Http.Headers;

namespace PR_Lab3
{
    public enum Incoterms //международный формат обозначения типа поставки
                          //распределение транспортных расходов продавец/покупатель, ответственность
                          //распределение рисков повреждения, утраты, кражи, уничтожения груза и т.д.
    {
        FOB = 1,
        FCA,
        CPT,
        CIP,
        DAT,
        DAP,
        DDP,
        EXW
    }

    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Director { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public Incoterms shipmentRegulations { get; set; }
        public List<Product> productList { get; set; }
        public double EmployeeNumber { get; set; }
        public double Revenue { get; set; }

    }
}
