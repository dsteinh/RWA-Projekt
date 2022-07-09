using Microsoft.ApplicationBlocks.Data;
using rwaLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rwaLib.Dal
{
    public class DBRepo : IRepo
    {
        //private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static string APARTMENTS_CS = ConfigurationManager.ConnectionStrings["apartments"].ConnectionString;

        public IList<Tag> LoadTags()
        {
            IList<Tag> tags = new List<Tag>();

            var tblTags = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadTags)).Tables[0];
            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(
                    new Tag
                    {
                        Id = (int)row[nameof(Tag.Id)],
                        NameEng = row[nameof(Tag.NameEng)].ToString(),
                        Type = new TagType { TypeId = Convert.ToInt32(row[nameof(TagType.TypeId)]), TypeName = row[nameof(TagType.TypeName)].ToString() },
                        ApartmentsUsing = (int)row[nameof(Tag.ApartmentsUsing)]
                    }
                );
            }

            return tags;
        }

        public void DeleteApartmentById(int id)
        {
            SqlHelper.ExecuteNonQuery(APARTMENTS_CS, nameof(DeleteApartmentById), id);

        }

        public IList<ApartmentOwner> LoadOwners()
        {
            IList<ApartmentOwner> owners = new List<ApartmentOwner>();

            var tblOwners = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadOwners)).Tables[0];
            foreach (DataRow row in tblOwners.Rows)
            {
                owners.Add(
                    new ApartmentOwner
                    {
                        OwnerId = (int)row[nameof(ApartmentOwner.OwnerId)],
                        Name = row[nameof(ApartmentOwner.Name)].ToString(),

                    }
                );
            }

            return owners;
        }

        public ApartmentReservation LoadApartmentsReservationById(int reservationId)
        {
            ApartmentReservation apartmentReservation = new ApartmentReservation();
            var tblApartmentReservation = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadApartmentsReservationById), reservationId).Tables[0];
            var row = tblApartmentReservation.Rows[0];
            return new ApartmentReservation
            {
                Id = (int)row[nameof(ApartmentReservation.Id)],
                ApartmentId = Convert.ToInt32(row[nameof(ApartmentReservation.ApartmentId)]),
                Details = row[nameof(ApartmentReservation.Details)].ToString(),
                FullName = row[nameof(ApartmentReservation.FullName)].ToString(),
                UserName = row[nameof(ApartmentReservation.UserName)].ToString(),
                UserEmail = row[nameof(ApartmentReservation.UserEmail)].ToString(),
            };
        }

        public string SelectMainPhoto(int apId)
        {
            ApartmentPicture picture;
            var tblImgs = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(SelectMainPhoto), apId).Tables[0];
            var row = tblImgs.Rows[0];
            picture = new ApartmentPicture
            {
                Base64Content = row[nameof(ApartmentPicture.Base64Content)].ToString(),
                Id = Convert.ToInt32(row[nameof(ApartmentPicture.Id)]),
                IsRepresentative = Convert.ToBoolean(row[nameof(ApartmentPicture.IsRepresentative)]),
                Name = row[nameof(ApartmentPicture.Name)].ToString()
            };
            return picture.Name;
        }

        public IList<Apartment> LoadApartmantsByStatus(string status)
        {
            IList<Apartment> apartments = new List<Apartment>();

            var tblApartments = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadApartmantsByStatus), status).Tables[0];
            foreach (DataRow row in tblApartments.Rows)
            {
                apartments.Add(
                    new Apartment
                    {
                        Id = Convert.ToInt32(row[nameof(Apartment.Id)]),
                        Name = row[nameof(Apartment.Name)].ToString(),
                        City = new City((int)row[nameof(City.Id)], row[nameof(Apartment.City)].ToString()),
                        Address = row[nameof(Apartment.Address)].ToString(),
                        MaxAdults = Convert.ToInt32(row[nameof(Apartment.MaxAdults)]),
                        MaxChildren = Convert.ToInt32(row[nameof(Apartment.MaxChildren)]),
                        TotalRooms = Convert.ToInt32(row[nameof(Apartment.TotalRooms)]),
                        Price = Convert.ToDouble(row[nameof(Apartment.Price)]),
                        Owner = new ApartmentOwner { OwnerId = Convert.ToInt32(row[nameof(Apartment.Owner.OwnerId)]), Name = row[nameof(Apartment.Owner)].ToString() },
                        Status = row[nameof(Apartment.Status)].ToString(),
                        BeachDistance = Convert.ToInt32(row[nameof(Apartment.BeachDistance)]),


                    }
                );
            }

            return apartments;
        }

        public IList<Apartment> LoadApartmentByCityName(string city)
        {
            IList<Apartment> apartments = new List<Apartment>();

            var tblApartments = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadApartmentByCityName), city).Tables[0];
            foreach (DataRow row in tblApartments.Rows)
            {
                apartments.Add(
                    new Apartment
                    {
                        Id = Convert.ToInt32(row[nameof(Apartment.Id)]),
                        Name = row[nameof(Apartment.Name)].ToString(),
                        City = new City((int)row[nameof(City.Id)], row[nameof(Apartment.City)].ToString()),
                        Address = row[nameof(Apartment.Address)].ToString(),
                        MaxAdults = Convert.ToInt32(row[nameof(Apartment.MaxAdults)]),
                        MaxChildren = Convert.ToInt32(row[nameof(Apartment.MaxChildren)]),
                        TotalRooms = Convert.ToInt32(row[nameof(Apartment.TotalRooms)]),
                        Price = Convert.ToDouble(row[nameof(Apartment.Price)]),
                        Owner = new ApartmentOwner { OwnerId = Convert.ToInt32(row[nameof(Apartment.Owner.OwnerId)]), Name = row[nameof(Apartment.Owner)].ToString() },
                        Status = row[nameof(Apartment.Status)].ToString(),
                        BeachDistance = Convert.ToInt32(row[nameof(Apartment.BeachDistance)]),


                    }
                );
            }

            return apartments;
        }

        public void CreateApartment(Apartment a)
        {
            SqlHelper.ExecuteNonQuery(APARTMENTS_CS, nameof(CreateApartment), Guid.NewGuid(), a.Name, a.Price, a.City.Id, a.Address, a.MaxAdults, a.MaxChildren, a.Status, a.TotalRooms, a.BeachDistance, a.Owner.OwnerId);

        }

        public IList<Tag> LoadTagsByApartmentId(int id)
        {
            IList<Tag> tags = new List<Tag>();

            var tblTags = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadTagsByApartmentId), id).Tables[0];
            foreach (DataRow row in tblTags.Rows)
            {
                tags.Add(
                    new Tag
                    {
                        Id = (int)row[nameof(Tag.Id)],
                        NameEng = row[nameof(Tag.NameEng)].ToString(),
                        Type = new TagType { TypeId = Convert.ToInt32(row[nameof(TagType.TypeId)]), TypeName = row[nameof(TagType.TypeName)].ToString() },

                    }
                );
            }

            return tags;
        }

        public IList<ApartmentPicture> LoadAllApartmentPictures(int id)
        {
            IList<ApartmentPicture> apartmentPictures = new List<ApartmentPicture>();
            var tblApartmentPictures = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadAllApartmentPictures), id).Tables[0];
            foreach (DataRow row in tblApartmentPictures.Rows)
            {
                apartmentPictures.Add(
                    new ApartmentPicture
                    {
                        Id = Convert.ToInt32(row[nameof(ApartmentPicture.Id)]),
                        Base64Content = row[nameof(ApartmentPicture.Base64Content)].ToString(),
                        Name = row[nameof(ApartmentPicture.Name)].ToString()
                        //IsRepresentative = (bool)row[nameof(ApartmentPicture.IsRepresentative)]
                    }
                );
            }

            return apartmentPictures;
        }

        public void MakeMainPhoto(string imgName, int apId)
        {
            SqlHelper.ExecuteNonQuery(APARTMENTS_CS, nameof(MakeMainPhoto), imgName, apId);
        }

        public void UpdateReservation(int id, string details, string regUser)
        {
            SqlHelper.ExecuteNonQuery(APARTMENTS_CS, nameof(UpdateReservation), id, details, regUser, DBNull.Value, DBNull.Value);
        }

        public void UpdateReservation(int id, string details, string unregUser, string email)
        {
            SqlHelper.ExecuteNonQuery(APARTMENTS_CS, nameof(UpdateReservation), id, details, DBNull.Value, unregUser, email);
        }

        public void CreateTag(string name, string type)
        {
            SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(CreateTag), name, type, Guid.NewGuid());

        }

        public IList<TagType> LoadTagTypes()
        {
            IList<TagType> tagTypes = new List<TagType>();
            var tblTagTypes = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadTagTypes)).Tables[0];
            foreach (DataRow row in tblTagTypes.Rows)
            {
                tagTypes.Add(
                    new TagType
                    {
                        TypeName = row[nameof(TagType.TypeName)].ToString(),
                    }
                );
            }

            return tagTypes;
        }

        public void DeleteTagById(int id)
        {
            SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(DeleteTagById), id);
        }

        public IList<ApartmentStatus> LoadStatus()
        {
            IList<ApartmentStatus> apartmentStatuses = new List<ApartmentStatus>();

            var tblStatus = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadStatus)).Tables[0];
            foreach (DataRow row in tblStatus.Rows)
            {
                apartmentStatuses.Add(
                    new ApartmentStatus
                    {
                        Id = (int)row[nameof(ApartmentStatus.Id)],
                        NameEng = row[nameof(ApartmentStatus.NameEng)].ToString(),
                    }
                );
            }

            return apartmentStatuses;
        }

        public IList<ApartmentReservation> LoadApartmentsReservationsByApartmentId(int id)
        {
            IList<ApartmentReservation> reservations = new List<ApartmentReservation>();

            var tblReservations = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadApartmentsReservationsByApartmentId), id).Tables[0];
            foreach (DataRow row in tblReservations.Rows)
            {
                reservations.Add(
                    new ApartmentReservation
                    {
                        Id = Convert.ToInt32(row[nameof(ApartmentReservation.Id)]),
                        ApartmentId = Convert.ToInt32(row[nameof(ApartmentReservation.ApartmentId)]),
                        Details = Convert.ToString(row[nameof(ApartmentReservation.Details)]),
                        UserAddress = Convert.ToString(row[nameof(ApartmentReservation.UserAddress)]),
                        UserEmail = Convert.ToString(row[nameof(ApartmentReservation.UserEmail)]),
                        FullName = row[nameof(ApartmentReservation.FullName)] != DBNull.Value ?
                        Convert.ToString(row[nameof(ApartmentReservation.FullName)]) : Convert.ToString(row[nameof(ApartmentReservation.UserName)]),
                        UserPhone = Convert.ToString(row[nameof(ApartmentReservation.UserPhone)])
                    }
                );
            }

            return reservations;

        }

        public void AddTagToApartment(string tag, int apId)
        {
            SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(AddTagToApartment), Guid.NewGuid(), tag, apId);
        }

        public void RemoveTagById(int tagId, int apId)
        {
            SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(RemoveTagById), tagId, apId);
        }

        public void DeletePictureById(int id)
        {
            SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(DeletePictureById), id);
        }

        public void CreatePicture(int id, ApartmentPicture p)
        {
            SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(CreatePicture), Guid.NewGuid(), id, p.Base64Content, p.Name);

        }

        public IList<Apartment> LoadApartmentsByTagID(int tagID)
        {
            IList<Apartment> apartments = new List<Apartment>();

            var tblApartments = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadApartmentsByTagID), tagID).Tables[0];
            foreach (DataRow row in tblApartments.Rows)
            {
                apartments.Add(
                    new Apartment
                    {
                        Name = row[nameof(Tag.NameEng)].ToString()
                    }
                );
            }

            return apartments;
        }
        public Apartment LoadApartmentByID(int apartmentID)
        {
            Apartment apartments = new Apartment();
            var tblApartments = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadApartmentByID), apartmentID).Tables[0];
            var row = tblApartments.Rows[0];
            return new Apartment
            {
                Id = Convert.ToInt32(row[nameof(Apartment.Id)]),
                Name = row[nameof(Apartment.Name)].ToString(),
                City = new City((int)row[nameof(City.Id)], row[nameof(Apartment.City)].ToString()),
                Address = row[nameof(Apartment.Address)].ToString(),
                MaxAdults = Convert.ToInt32(row[nameof(Apartment.MaxAdults)]),
                MaxChildren = Convert.ToInt32(row[nameof(Apartment.MaxChildren)]),
                TotalRooms = Convert.ToInt32(row[nameof(Apartment.TotalRooms)]),
                Price = Convert.ToDouble(row[nameof(Apartment.Price)]),
                Owner = new ApartmentOwner { OwnerId = Convert.ToInt32(row[nameof(Apartment.Owner.OwnerId)]), Name = row[nameof(Apartment.Owner)].ToString() },
                Status = row[nameof(Apartment.Status)].ToString(),
                BeachDistance = Convert.ToInt32(row[nameof(Apartment.BeachDistance)])
            };
        }

        public void UpdateApartment(Apartment a)
        {
            SqlHelper.ExecuteNonQuery(APARTMENTS_CS, nameof(UpdateApartment), a.Id, a.Name, a.Price, a.City.Id, a.Address, a.MaxAdults, a.MaxChildren, a.Status, a.TotalRooms, a.BeachDistance);
        }

        public IList<Apartment> LoadAllApartments()
        {
            IList<Apartment> apartments = new List<Apartment>();

            var tblApartments = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadAllApartments)).Tables[0];
            foreach (DataRow row in tblApartments.Rows)
            {
                apartments.Add(
                    new Apartment
                    {
                        Id = Convert.ToInt32(row[nameof(Apartment.Id)]),
                        Name = row[nameof(Apartment.Name)].ToString(),
                        City = new City((int)row[nameof(City.Id)], row[nameof(Apartment.City)].ToString()),
                        Address = row[nameof(Apartment.Address)].ToString(),
                        MaxAdults = Convert.ToInt32(row[nameof(Apartment.MaxAdults)]),
                        MaxChildren = Convert.ToInt32(row[nameof(Apartment.MaxChildren)]),
                        TotalRooms = Convert.ToInt32(row[nameof(Apartment.TotalRooms)]),
                        Price = Convert.ToDouble(row[nameof(Apartment.Price)]),
                        Owner = new ApartmentOwner { OwnerId = Convert.ToInt32(row[nameof(Apartment.Owner.OwnerId)]), Name = row[nameof(Apartment.Owner)].ToString() },
                        Status = row[nameof(Apartment.Status)].ToString(),
                        BeachDistance = Convert.ToInt32(row[nameof(Apartment.BeachDistance)]),


                    }
                );
            }

            return apartments;
        }
        //public void AddUser(User user)
        //{
        //    SqlHelper.ExecuteNonQuery(APARTMENTS_CS, nameof(AddUser), user.FName, user.LName, user.City.Id, user.Username, user.Password);
        //}

        //public User AuthUser(string username, string password)
        //{
        //    var tblAuth = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(AuthUser), username, password).Tables[0];
        //    if (tblAuth.Rows.Count == 0) return null;

        //    DataRow row = tblAuth.Rows[0];
        //    return new User
        //    {
        //        IDAuth = (int)row[nameof(User.IDAuth)],
        //        FName = row[nameof(User.FName)].ToString(),
        //        LName = row[nameof(User.LName)].ToString(),
        //        City = new City((int)row[nameof(City.IDCity)], row[nameof(City.Name)].ToString()),
        //        Username = row[nameof(User.Username)].ToString(),
        //        Password = row[nameof(User.Password)].ToString()
        //    };
        //}

        public IList<City> LoadCities()
        {
            IList<City> cities = new List<City>();

            var tblCities = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadCities)).Tables[0];
            foreach (DataRow row in tblCities.Rows)
            {
                cities.Add(
                    new City
                    {
                        Id = (int)row[nameof(City.Id)],
                        Name = row[nameof(City.Name)].ToString(),
                    }
                );
            }

            return cities;
        }

        public IList<User> LoadUsers()
        {
            IList<User> users = new List<User>();

            var tblUsers = SqlHelper.ExecuteDataset(APARTMENTS_CS, nameof(LoadUsers)).Tables[0];
            foreach (DataRow row in tblUsers.Rows)
            {
                users.Add(
                    new User
                    {
                        Id = (int)row[nameof(User.Id)],
                        Username = row[nameof(User.Username)].ToString(),

                    }
                );
            }

            return users;
        }


    }
}
