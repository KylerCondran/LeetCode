--Title: 182. Duplicate Emails
--Link: https://leetcode.com/problems/duplicate-emails
--Tags: Database
SELECT email FROM Person GROUP BY email HAVING COUNT(*) > 1;
--Title: 196. Delete Duplicate Emails
--Link: https://leetcode.com/problems/delete-duplicate-emails
--Tags: Database
DELETE FROM Person WHERE id NOT IN (SELECT MIN(id) FROM Person GROUP BY email)
--Title: 584. Find Customer Referee
--Link: https://leetcode.com/problems/find-customer-referee
--Tags: Database
SELECT name FROM Customer WHERE referee_id <> 2 OR referee_id IS NULL
--Title: 595. Big Countries
--Link: https://leetcode.com/problems/big-countries
--Tags: Database
SELECT name, population, area FROM World WHERE area >= 3000000 OR population >= 25000000
--Title: 620. Not Boring Movies
--Link: https://leetcode.com/problems/not-boring-movies
--Tags: Database
SELECT * FROM Cinema WHERE MOD(id, 2) <> 0 AND description <> 'boring' ORDER BY rating DESC
--Title: 1068. Product Sales Analysis I
--Link: https://leetcode.com/problems/product-sales-analysis-i
--Tags: Database
SELECT b.product_name, a.year, a.price FROM Sales AS a INNER JOIN Product AS b ON a.product_id = b.product_id
--Title: 1148. Article Views I
--Link: https://leetcode.com/problems/article-views-i
--Tags: Database
SELECT DISTINCT author_id AS id FROM Views WHERE viewer_id = author_id ORDER BY author_id ASC
--Title: 1378. Replace Employee ID With The Unique Identifier
--Link: https://leetcode.com/problems/replace-employee-id-with-the-unique-identifier
--Tags: Database
SELECT b.unique_id, a.name FROM Employees AS a LEFT JOIN EmployeeUNI AS b ON a.id = b.id 
--Title: 1527. Patients With a Condition
--Link: https://leetcode.com/problems/patients-with-a-condition
--Tags: Database
SELECT patient_id, patient_name, conditions FROM Patients WHERE conditions like '%DIAB1%' AND conditions NOT IN ('SADIAB100')
--Title: 1581. Customer Who Visited but Did Not Make Any Transactions
--Link: https://leetcode.com/problems/customer-who-visited-but-did-not-make-any-transactions
--Tags: Database
SELECT customer_id, COUNT(*) AS [count_no_trans] FROM Visits WHERE visit_id NOT IN (SELECT visit_id FROM Transactions) GROUP BY customer_id
--Title: 1667. Fix Names in a Table
--Link: https://leetcode.com/problems/fix-names-in-a-table
--Tags: Database
SELECT user_id, UPPER(LEFT(name,1))+LOWER(SUBSTRING(name,2,LEN(name))) AS [name] FROM Users ORDER BY user_id
--Title: 1683. Invalid Tweets
--Link: https://leetcode.com/problems/invalid-tweets
--Tags: Database
SELECT tweet_id FROM Tweets WHERE LEN(content) > 15
--Title: 1757. Recyclable and Low Fat Products
--Link: https://leetcode.com/problems/recyclable-and-low-fat-products
--Tags: Database
SELECT product_id FROM Products WHERE low_fats = 'Y' AND recyclable = 'Y'
--Title: 596. Classes More Than 5 Students
--Link: https://leetcode.com/problems/classes-more-than-5-students
--Tags: Database
SELECT class FROM Courses GROUP BY class HAVING COUNT(class) > 4
--Title: 1729. Find Followers Count
--Link: https://leetcode.com/problems/find-followers-count
--Tags: Database
SELECT user_id, count(*) as [followers_count] FROM Followers GROUP BY user_id
--Title: 619. Biggest Single Number
--Link: https://leetcode.com/problems/biggest-single-number
--Tags: Database
SELECT MAX(num) AS [num] FROM (SELECT num FROM MyNumbers GROUP BY num HAVING COUNT(num) < 2) T
--Title: 2356. Number of Unique Subjects Taught by Each Teacher
--Link: https://leetcode.com/problems/number-of-unique-subjects-taught-by-each-teacher
--Tags: Database
SELECT teacher_id, count(*) as [cnt] FROM (SELECT teacher_id, subject_id FROM Teacher GROUP BY teacher_id, subject_id) T GROUP BY teacher_id