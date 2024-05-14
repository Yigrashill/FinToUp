import { Company } from "./Company";

export  interface Job {
    id : number,
    type : string;
    title : string;
    description : string;
    location : string;
    salary : string;
    company : Company;
  }

