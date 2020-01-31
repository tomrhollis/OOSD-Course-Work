

create view invoicebasic as
select vendorname, invoicenumber, invoicetotal from invoices inner join vendors on invoices.vendorid = vendors.vendorid

select * from invoicebasic


select * from invoicebasic where left(vendorname,1) in ('N','O','P') order by vendorname




drop view top10paidinvoices
create view top10paidinvoices as
(select top 10 vendorname, max(invoicedate) as lastinvoice, sum(invoicetotal) as sumofinvoices
from vendors v inner join invoices i on v.vendorid = i.vendorid
where (invoicetotal - paymenttotal - credittotal) <= 0
group by vendorname
order by 3 desc)

select * from top10paidinvoices