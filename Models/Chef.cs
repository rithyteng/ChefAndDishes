    using System.ComponentModel.DataAnnotations;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using System.Collections.Generic;


namespace chefanddishes.Models
    {
        public class Chef
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int Id { get; set; }
            // MySQL VARCHAR and TEXT types can be represeted by a string
            public int Did{get;set;}

            [Required(ErrorMessage="Please Input Your First Name")]
            public string FirstName { get; set; }
            [Required(ErrorMessage="Please Input Your Last Name")]

            public string LastName { get; set; }

            
            
            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{yyyyMMdd}")]
            public DateTime DOB {get;set;}
            // The MySQL DATETIME type can be represented by a DateTime
            public int Age {get{
                string now = DateTime.Now.ToString("yyyyMMdd");
                string dobchef = this.DOB.ToString("yyyyMMdd");
                
                string dobchefyear="";
                string dobchefmonth="";
                string dobchefdate="";
                string nowofyear="";
                string nowofmonth="";
                string nowofdate="";


                for(int i =0; i <4; i ++){
                    dobchefyear += dobchef[i];
                }
                for(int i =4; i<6;i++){
                    dobchefmonth +=dobchef[i];
                }
                for(int i =6; i<8;i++){
                    dobchefdate +=dobchef[i];
                }
                //----------------------------------------------------------------
                for(int i =0; i <4; i ++){
                    nowofyear += now[i];
                }
                for(int i =4; i<6;i++){
                    nowofmonth +=now[i];
                }
                for(int i =6; i<8;i++){
                    nowofdate +=now[i];
                }

                int nowofyear2 = Int32.Parse(nowofyear);
                int dobchefyear2 = Int32.Parse(dobchefyear);

                int nowofmonth2 = Int32.Parse(nowofmonth);
                int dobchefmonth2 = Int32.Parse(dobchefmonth);

                int nowofdate2 = Int32.Parse(nowofdate);
                int dobchefdate2 = Int32.Parse(dobchefdate);
                int myage = nowofyear2-dobchefyear2;
                return myage;
            }set{
            }}
            public List <Dishes> MyDish {get;set;}
            public DateTime CreatedAt {get;set;} = DateTime.Now; //Add to Datetime.NOW
            public DateTime UpdatedAt {get;set;} =  DateTime.Now; //Add to Datetime.NOW
        }

        public class Dishes{
            [Key]
            public int Did{get;set;}
            
            [Display(Name = "Chef Name:")]
            public int Id{get;set;}
            [Required]
            public string nameofdish {get;set;}
            [Required]
            public int calories{get;set;}
            [Required]
            public int tastiness {get;set;}
            [Required]
            public string description{get;set;} 

            public Chef myChef {get;set;}
            public DateTime CreatedAt {get;set;} = DateTime.Now; //Add to Datetime.NOW
            public DateTime UpdatedAt {get;set;} =  DateTime.Now; //Add to Datetime.NOW

        }
    }
    