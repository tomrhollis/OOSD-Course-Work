select * from ar_invoices
update ar_invoices
set current_month_interest_charges = invoice_amount * 0.02, total_interest_charges = total_interest_charges + (invoice_amount * 0.02)
where datediff(day,invoice_date, getdate()) <= 365/12

select customer_name,sum(current_month_interest_charges) as interest 
from ar_invoices i inner join ar_customers c on i.customer#=c.customer#
group by customer_name


select customer_name,(sum(total_interest_charges)+sum(invoice_amount)) as balance
from ar_invoices i inner join ar_customers c on i.customer#=c.customer#
where i.amount_paid < (i.invoice_amount + i.total_interest_charges)
group by customer_name


select salesperson_name, sum(invoice_amount)
from ar_salespeople s inner join ar_invoices i on s.salesperson#=i.salesperson#
where datediff(day,invoice_date, getdate()) <= 365
group by salesperson_name

select customer_province, sum(invoice_amount)
from ar_invoices i inner join ar_customers c on i.customer#=c.customer#
where datediff(day,invoice_date,getdate()) <= (365/12)
group by customer_province

select salesperson_name as "On Notice"
from ar_salespeople s left outer join ar_invoices i on s.salesperson#=i.salesperson#
where invoice# is null

select customer_name, customer_rating, count(*) as "Order Count"
from ar_customers c inner join ar_invoices i on c.customer#=i.customer#
where datediff(day, invoice_date, getdate()) <= 365 and customer_rating <= 2
group by customer_name, customer_rating
having count(*) > 1

select salesperson_name
from ar_salespeople s inner join ar_invoices i on s.salesperson#=i.salesperson#
inner join ar_customers c on i.customer#=c.customer#
where customer_rating=3


select top 1 salesperson_name, sum(invoice_amount) as total
from ar_salespeople s inner join ar_invoices i on s.salesperson#=i.salesperson#
group by salesperson_name
order by 2 desc





