create database flex;
use flex;


select log_id,table_name,user_id,change_date,change_type from log_table
CREATE TABLE log_table (
    log_id INT IDENTITY(1,1) PRIMARY KEY,
    table_name VARCHAR(255),
    user_id varchar(255),
    change_date DATETIME DEFAULT GETDATE(),
    change_type VARCHAR(255),
    --change_description VARCHAR(255)
);


create table usersforlog
(
	ID varchar(255),
	priority int,

	foreign key(ID) references users(username)

);


CREATE TRIGGER log_users_change_ins
ON users
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('User', @loggedInUserId, GETDATE(), 'INSERTED');
END

CREATE TRIGGER log_users_change_upt
ON users
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('User', @loggedInUserId, GETDATE(), 'INSERTED');
END


CREATE TRIGGER log_users_change_del
ON users
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('User', @loggedInUserId, GETDATE(), 'INSERTED');
END


CREATE TRIGGER log_admin_change_ins
ON admin
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Admin', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_admin_change_upt
ON admin
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Admin', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_admin_change_del
ON admin
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Admin', @loggedInUserId, GETDATE(), 'DELETED');
END


--3

CREATE TRIGGER log_faculty_change_ins
ON faculty
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Faculty', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_faculty_change_upt
ON faculty
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Faculty', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_faulty_change_del
ON faculty
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Faculty', @loggedInUserId, GETDATE(), 'DELETED');
END


--4

CREATE TRIGGER log_students_change_ins
ON students
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Students', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_students_change_upt
ON students
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Students', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_users_students_del
ON students
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Students', @loggedInUserId, GETDATE(), 'DELETED');
END

--5


CREATE TRIGGER log_studies_change_ins
ON studies
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Studies', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_studies_change_upt
ON studies
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Studies', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_studies_change_del
ON studies
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Studies', @loggedInUserId, GETDATE(), 'DELETED');
END

--6


CREATE TRIGGER log_grades_change_ins
ON grades
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Grades', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_grades_change_upt
ON grades
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Grades', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_grades_change_del
ON grades
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Grades', @loggedInUserId, GETDATE(), 'DELETED');
END

--7

CREATE TRIGGER log_courses_change_ins
ON courses
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Courses', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_courses_change_upt
ON courses
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Courses', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_courses_change_del
ON courses
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Courses', @loggedInUserId, GETDATE(), 'DELETED');
END

--8

CREATE TRIGGER log_prereq_change_ins
ON prereq
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Prereq', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_prereq_change_upt
ON prereq
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Prereq', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_prereq_change_del
ON prereq
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Prereq', @loggedInUserId, GETDATE(), 'DELETED');
END

--9


CREATE TRIGGER log_section_change_ins
ON sections
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Section', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_section_change_upt
ON sections
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Section', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_section_change_del
ON sections
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Section', @loggedInUserId, GETDATE(), 'DELETED');
END

--10

CREATE TRIGGER log_attendence_change_ins
ON attendance
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Attendence', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_attendence_change_upt
ON attendance
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Attendence', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_attendence_change_del
ON attendance
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Attendence', @loggedInUserId, GETDATE(), 'DELETED');
END

--11

CREATE TRIGGER log_quiz_change_ins
ON quiz
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Quiz', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_quiz_change_upt
ON quiz
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Quiz', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_quiz_change_del
ON quiz
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Quiz', @loggedInUserId, GETDATE(), 'DELETED');
END

--12

CREATE TRIGGER log_assignment_change_ins
ON Assignment
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Assignment', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_assignment_change_upt
ON Assignment
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Assignment', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_assignment_change_del
ON Assignment
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Assignment', @loggedInUserId, GETDATE(), 'DELETED');
END



--14
CREATE TRIGGER log_sessional_change_ins
ON sessionals
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('sessional', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_sessional_change_upt
ON sessionals
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Sessional', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_sessional_change_del
ON sessionals
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Sessional', @loggedInUserId, GETDATE(), 'DELETED');
END

--15


CREATE TRIGGER log_final_change_ins
ON final
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Finals', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_final_change_upt
ON final
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Finals', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_final_change_del
ON final
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Finals', @loggedInUserId, GETDATE(), 'DELETED');
END

--16


CREATE TRIGGER log_project_change_ins
ON project
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Project', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_project_change_upt
ON project
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Project', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_project_change_del
ON project
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Project', @loggedInUserId, GETDATE(), 'DELETED');
END

--17
select * from usersforlog

CREATE TRIGGER log_feedback_change_ins
ON feedback
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Feedback', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_feedback_change_upt
ON feedback
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Feedback', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_feedback_change_del
ON feedback
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Feedback', @loggedInUserId, GETDATE(), 'DELETED');
END

--18

CREATE TRIGGER log_teaches_change_ins
ON teaches
AFTER INSERT 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Teaches', @loggedInUserId, GETDATE(), 'INSERTED');
END



CREATE TRIGGER log_teaches_change_upt
ON teaches
AFTER UPDATE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    

    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Teaches', @loggedInUserId, GETDATE(), 'UPDATED');
END



CREATE TRIGGER log_teaches_change_del
ON users
AFTER DELETE 
AS 
BEGIN
    DECLARE @loggedInUserId varchar(255);

    -- Retrieve the user ID of the logged-in user
    SELECT top(1) @loggedInUserId = ID FROM usersforlog order by priority desc;
    
	 
    INSERT INTO log_table (table_name, user_id, change_date, change_type)
    VALUES ('Teaches', @loggedInUserId, GETDATE(), 'DELETED');
END



create table users
(
	username varchar (255),
	password varchar(255),
	role varchar(255),
	name varchar(255),
	DOB date,
	blood_group varchar(255),
	gender varchar(255),
	CNIC varchar(255),
	nationality varchar(255),
	email varchar(255),
	contact varchar(255),
	campus varchar(255)

	primary key(username)
);


create table admin 
(
	username varchar(255),
	
	primary key (username),
	foreign key (username) references users(username) on delete cascade on update cascade
);


create table faculty
(
	username varchar(255),
	room_number varchar(255),
	subject varchar(255),
	school_year varchar(255),

	primary key (username),
	foreign key (username) references users(username) on delete cascade on update cascade
);

create table sections
(
	name varchar(255), 
	primary key(name)
);

create table students
(
	Roll_num varchar(255),
	father_name varchar(255),
	address varchar(255),
	reg_no varchar(255),
	status varchar(255),
	semester varchar(255),
	degree varchar(255),
	batch varchar(255),
	city varchar(255),
	country varchar(255),

	primary key(Roll_num),
	foreign key (Roll_num) references users(username) on delete cascade on update cascade,
	foreign key (section) references sections(name) on delete cascade on update cascade,
);

create table courses
(
	ID varchar(255),
	name varchar(255),
	credit_hours int,
	assignment_w int,
	quiz_w int,
	sessionals_w int,
	finals_w int,
	project_w int,
	semester int,
	
	primary key(ID)
	
);


create table prereq
(
	ID varchar(255),
	prereq_ID varchar(255),

	foreign key (ID) references courses(ID),
	foreign key (prereq_ID) references courses(ID),
	
);


create table studies
(
	student_ID varchar(255),
	course_ID varchar(255),
	section varchar(255),

	primary key (student_id,Course_id),
	foreign key (student_ID) references students(Roll_num),
	foreign key (course_ID) references courses(ID),
	foreign key (section) references sections(name)
);


create table teaches
(
	faculty_ID varchar(255),
	section varchar(255),
	course_ID varchar(255),

	primary key(faculty_ID,course_ID),
	foreign key (faculty_ID) references faculty(username),
	foreign key (section) references sections(name) on delete cascade on update cascade,
	foreign key (course_ID) references courses(ID)  on delete cascade on update cascade
);


create table grades
(
	student_ID varchar(255),
	course_ID varchar(255),
	grade varchar(255),

	primary key(student_ID,course_ID),
	foreign key (student_ID) references students(Roll_num),
	foreign key (course_ID) references courses(ID) on delete cascade on update cascade

);

create table attendance
(            
	student_ID varchar(255),         
	date date,
	section varchar(255),
	faculty_ID varchar(255),
	status varchar(255),                           
	course_id varchar(255),
	
	primary key (student_ID,date),
	foreign key (section) references sections(name),
	foreign key (student_ID) references students(Roll_num),
	foreign key (faculty_ID) references faculty (username),
	foreign key (course_id) references courses(ID)  on delete cascade on update cascade

);


create table quiz
(

obtained_marks int,
total_marks int,
course_ID varchar(255),
student_ID varchar(255),
faculty_ID varchar(255),

foreign key (course_ID) references courses(ID),
foreign key (student_ID) references students(Roll_num),
foreign key (faculty_ID) references faculty(username)

);

create table Assignment
(

obtained_marks int,
total_marks int,
course_ID varchar(255),
student_ID varchar(255),
faculty_ID varchar(255),


foreign key (course_ID) references courses(ID),
foreign key (student_ID) references students(Roll_num),
foreign key (faculty_ID) references faculty(username)

);

create table sessionals
(

obtained_marks int,
total_marks int,
course_ID varchar(255),
student_ID varchar(255),
faculty_ID varchar(255),


foreign key (course_ID) references courses(ID),
foreign key (student_ID) references students(Roll_num),
foreign key (faculty_ID) references faculty(username)

);


create table project
(

obtained_marks int,
total_marks int,
course_ID varchar(255),
student_ID varchar(255),
faculty_ID varchar(255),


foreign key (course_ID) references courses(ID),
foreign key (student_ID) references students(Roll_num),
foreign key (faculty_ID) references faculty(username)
);

create table final
(

obtained_marks int,
total_marks int,
course_ID varchar(255),
student_ID varchar(255),
faculty_ID varchar(255),

foreign key (course_ID) references courses(ID),
foreign key (student_ID) references students(Roll_num),
foreign key (faculty_ID) references faculty(username)


);


create table feedback
(
	student_ID varchar(255), 
	course_ID varchar(255),
	faculty_ID varchar(255),
	description varchar(255),
	percentage varchar(255),

	primary key (student_ID,course_ID,faculty_ID),
	foreign key (student_ID) references students(Roll_num),
	foreign key (course_ID) references courses(ID),
	foreign key (faculty_ID) references faculty(username)
);


BULK INSERT users
from 'C:\Users\alium\Desktop\populated data\Users.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);

BULK INSERT admin
from 'C:\Users\alium\Desktop\populated data\Admin.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);


BULK INSERT faculty
from 'C:\Users\alium\Desktop\populated data\Faculty.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);


BULK INSERT students
from 'C:\Users\alium\Desktop\populated data\Students.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);

BULK INSERT studies
from 'C:\Users\alium\Desktop\populated data\Studies.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);


BULK INSERT grades
from 'C:\Users\alium\Desktop\populated data\Grades.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);


BULK INSERT courses
from 'C:\Users\alium\Desktop\populated data\Courses.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);


BULK INSERT prereq
from 'C:\Users\alium\Desktop\populated data\Prereq.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);


BULK INSERT sections
from 'C:\Users\alium\Desktop\populated data\Sections.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);

BULK INSERT attendance
from 'C:\Users\alium\Desktop\populated data\Attendance.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);

BULK INSERT quiz
from 'C:\Users\alium\Desktop\populated data\Quiz.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);

BULK INSERT assignment
from 'C:\Users\alium\Desktop\populated data\Assignment.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);


BULK INSERT sessionals
from 'C:\Users\alium\Desktop\populated data\Sessionals.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);


BULK INSERT project
from 'C:\Users\alium\Desktop\populated data\Project.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);



BULK INSERT final
from 'C:\Users\alium\Desktop\populated data\Finals.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);



BULK INSERT feedback
from 'C:\Users\alium\Desktop\populated data\Feedback.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);



BULK INSERT teaches
from 'C:\Users\alium\Desktop\populated data\teaches.csv'
with
(
fieldterminator = ',',
rowterminator = '\n',
firstrow = 2 , KEEPNULLS
);
