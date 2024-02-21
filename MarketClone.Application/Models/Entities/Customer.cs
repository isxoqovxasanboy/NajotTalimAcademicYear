namespace MarketClone.Application.Models.Entities;

public class Customer
{
    public int Id { get; set; }
    
    public string CardNumber { get; set; } = default!;
    
    public decimal Discount { get; set; }
}


/*
SELECT CO.customer_id, P.person_first_name, P.person_last_name, SUM(COD.price_with_discount)
FROM customer_order CO LEFT JOIN order_details AS COD ON CO.customer_id = COD.customer_order_id
LEFT JOIN shop_products SP ON COD.product_id=SP.product_id 
LEFT JOIN persons AS P ON CO.customer_id=P.person_id
WHERE CO.customer_id IS NOT NULL
GROUP BY  CO.customer_id, P.person_first_name, P.person_last_name
ORDER BY SUM(COD.price_with_discount) DESC;
 */