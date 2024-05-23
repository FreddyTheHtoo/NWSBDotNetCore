namespace NWSBDotNetCore.PizzaApi.Queries
{
    public class PizzaQuery
    {
        public static string PizzaOrderQuery { get; } =
            @"SELECT po.*, p.Pizza, p.Price FROM [dbo].[Tbl_PizzaOrder] po
            INNER JOIN [dbo].[Tbl_Pizza] p on p.PizzaId=po.PizzaId
            WHERE PizzaOrderInvoiceNo = @PizzaOrderInvoiceNo";

        public static string PizzaOrderDetailQuery { get; } =
            @"SELECT pod.*, pe.PizzaExtraName, pe.Price FROM [dbo].[Tbl_PizzaOrderDetail] pod    
             INNER JOIN [dbo].[Tbl_PizzaExtra] pe on pod.PizzaExtraId= pe.PizzaExtraId
             WHERE PizzaOrderInvoiceNo=@PizzaOrderInvoiceNo";

    }
}
