namespace PersonalShcoolCard.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PersonalSchoolCard.Data;
    public class PictureDA
    {
        public static string GetPortraitPath(long studentID)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                var path = context.Pictures
                            .Where(picture => picture.StudentID == studentID)
                            .Select(picture => picture.PicturePath)
                            .FirstOrDefault();
                return path;
            }
        }
        public static void SetPortraitPath(long studentID,string path)
        {
            using(var context = new PersonalSchoolCardEntities())
            {
                if (context.Pictures
                        .Where(student => student.StudentID == studentID)
                        .Select(picture => picture)
                        .FirstOrDefault()==null)
                {                   
                    var pictureEntity = new Picture
                    {
                        StudentID = studentID,
                        PicturePath = path
                    };
                    context.Pictures.Add(pictureEntity);
                }
                else
                {
                    context.Pictures
                        .Where(student => student.StudentID == studentID)
                        .Select(picture => picture)
                        .FirstOrDefault().PicturePath = path;
                }
                
                context.SaveChanges();
            }
        }
    }
}
