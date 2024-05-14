export class User {
   UserName: string;
   Email: string;
   Password: string;
   ConfirmPassword: string;
   FirstName: string;
   LastName: string;
   PhoneNumber: string;
   Address: string;

  constructor(
    username: string,
    email: string,
    password: string,
    confirmPassword: string,
    firstName: string,
    lastName: string,
    phone: string,
    address: string
  ) {
    this.UserName = username;
    this.Email = email;
    this.Password = password;
    this.ConfirmPassword = confirmPassword;
    this.FirstName = firstName;
    this.LastName = lastName;
    this.PhoneNumber = phone;
    this.Address = address;
  }
}
