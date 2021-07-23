

-- SQL sample
SELECT Business, ISNULL(StreetNo, '') as 'StreetNo', Street, PostCode, SUM(ISNULL(f.count, 0)) as 'FootfallCount'
FROM Businesses b (nolock)
JOIN Premises p (nolock) ON p.BusinessId = b.Id
LEFT JOIN FootFall f (nolock) ON f.PremisesId = p.Id
GROUP BY Business, StreetNo, Street, PostCode
