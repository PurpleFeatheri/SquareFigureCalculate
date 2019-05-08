SQL query:

SELECT p.Name as product, ISNULL(c.Name, '-') as category
FROM Product p
LEFT JOIN ProductByCategory pc on pc.ProductId = p.Id
LEFT JOIN Category c on c.Id = pc.CategoryId
