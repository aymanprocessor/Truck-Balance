SELECT        Wieghts.Id, Wieghts.date, Wieghts.driverName, Wieghts.truckType, Wieghts.payloadType, Wieghts.export_import, Wieghts.truckNumber, Wieghts.containerNumber, Wieghts.firstWieght, Wieghts.firstTime, 
                         Wieghts.secondWieght, Wieghts.secondTime, Wieghts.finalWieght, Wieghts.note, Customers.name
FROM            Wieghts INNER JOIN
                         Customers ON Wieghts.customerId = Customers.Id 
WHERE        (Wieghts.Id =17)