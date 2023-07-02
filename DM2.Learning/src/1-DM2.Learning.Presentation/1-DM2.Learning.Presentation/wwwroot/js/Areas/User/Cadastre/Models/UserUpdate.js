export class UserUpdate {
    constructor(Id, Name, Age) {
        this.Id = Id,
        this.Name = Name,
        this.Age = Number(Age)
    }
}