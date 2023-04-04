import { User } from "./User";

export class Galery{
    constructor(public Id : number,
            public Name : string,
            public IsPublic : boolean,
            public DefaultImage : string,
            public AllowedUsers : User[]){}
}