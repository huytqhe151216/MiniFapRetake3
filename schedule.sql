select * from Schedule s, [User] u, Course c , UserCourse uc
where s.CourseId = c.CourseId and u.UserId = uc.UserId and c.CourseId = uc.CourseId
