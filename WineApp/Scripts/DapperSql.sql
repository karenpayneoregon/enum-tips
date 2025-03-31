--- .\SQLEXPRESS    EF.Wines

SELECT      w.WineId,
            w.Name AS WineName,
            wt.TypeName AS WineType,
            wt.Description AS TypeDescription
  FROM      dbo.Wines w
 INNER JOIN dbo.WineType wt
    ON w.WineType = wt.Id
 ORDER BY w.WineId;
 

SELECT      w.WineId,
            MAX(w.Name) AS WineName,
            MAX(wt.TypeName) AS WineType,
            MAX(wt.Id) AS TypeDescription
  FROM      dbo.Wines w
 INNER JOIN dbo.WineType wt
    ON w.WineType = wt.Id
 GROUP BY w.WineId
 ORDER BY WineType ASC,
          WineName ASC;

SELECT      w.WineId AS WineId,
            w.Name AS WineName,
            wt.TypeName AS WineType,
            wt.Description AS TypeDescription
  FROM      dbo.Wines w
 INNER JOIN dbo.WineType wt
    ON w.WineType = wt.Id
 ORDER BY wt.TypeName ASC,
          w.Name ASC;


