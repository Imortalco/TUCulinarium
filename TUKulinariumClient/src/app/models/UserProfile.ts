export class UserProfile {
   UserName: string;

   FirstName: string;

   LastName: string;

   Email: string;

   PhoneNumber: string;

   Address: string;
  
  constructor(
    username: string,
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    address: string
  ) {
    this.UserName = username;
    this.FirstName = firstName;
    this.LastName = lastName;
    this.Email = email;
    this.PhoneNumber = phoneNumber;
    this.Address = address;
  }
}
