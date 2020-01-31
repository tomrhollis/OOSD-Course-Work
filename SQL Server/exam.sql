DROP TABLE registrations
DROP TABLE courses
DROP TABLE students
DROP TABLE instructors


CREATE TABLE instructors
(instructor_name VARCHAR(50) PRIMARY KEY, -- primary key would ideally be a ID instead, but following specification
office_room VARCHAR(6)) -- allows nulls because budget cuts could mean no office for a new person for a bit

CREATE TABLE students
(student# INT IDENTITY(1,1) PRIMARY KEY,
student_name VARCHAR(50) NOT NULL,
email VARCHAR(50) CONSTRAINT ck_students_email CHECK(email LIKE '_%@_%._%'),
major VARCHAR(50)) -- ideally "majorID INT FOREIGN KEY REFERENCES majors(majorID)" but we don't have that table

CREATE TABLE courses
(course# VARCHAR(8) PRIMARY KEY, -- assuming something like ABCD1234
course_name VARCHAR(50) NOT NULL,
instructor_name VARCHAR(50) FOREIGN KEY REFERENCES instructors(instructor_name))

CREATE TABLE registrations
(student# INTEGER FOREIGN KEY REFERENCES students(student#) ON DELETE CASCADE,
course# VARCHAR(8) FOREIGN KEY REFERENCES courses(course#) ON DELETE CASCADE,
grade CHAR(1),
PRIMARY KEY(student#, course#))



INSERT INTO instructors(instructor_name,office_room) VALUES('Tom Hollis','AB245'),('Bob Robertson','CD167')

INSERT INTO students(student_name,email,major) VALUES('Al Albertson','al1234@gmail.com','Accounting'),('Carol Channing','cc123@yahoo.ca','Drama')

INSERT INTO courses(course#,course_name,instructor_name) VALUES('HIKE1234','Hiking Instead of Class','Tom Hollis'),('CLAS4321','Learn a Thing','Bob Robertson')

INSERT INTO registrations(student#,course#,grade) VALUES(1,'HIKE1234','A'),(2,'CLAS4321','A')


UPDATE registrations
SET grade='W'
WHERE student#=1

SELECT course_name, COUNT(*) as number_of_students
FROM courses c INNER JOIN registrations r ON c.course#=r.course#
GROUP BY course_name

--need to make an unassigned instructor first to prove it works
INSERT INTO instructors(instructor_name,office_room) VALUES('The New Guy','CLOSET')
SELECT i.instructor_name
FROM instructors i LEFT OUTER JOIN courses c ON i.instructor_name=c.instructor_name
WHERE c.course# IS NULL

SELECT DISTINCT major
FROM students
ORDER by major

SELECT student_name,course_name,grade
FROM students s INNER JOIN registrations r ON s.student#=r.student#
INNER JOIN courses c ON r.course#=c.course#
ORDER BY student_name


-- before
SELECT * from courses
SELECT * from registrations
SELECT * from instructors

-- cascade deleting added to the registration table in anticipation of this question
DELETE FROM courses
WHERE instructor_name='Tom Hollis'

-- after
SELECT * from courses
SELECT * from registrations
SELECT * from instructors