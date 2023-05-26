export interface IPerson {
  id: number;
  firstName: string;
  lastName: string;
  authorised: boolean;
  valid: boolean;
  enabled: boolean;
  palindrome: boolean;
  favouriteSports: ISport[];
}

export interface IPersonUpdate {
  firstName: string;
  lastName: string;
  authorised: boolean;
  valid: boolean;
  enabled: boolean;
  favouriteSports: number[];
}

export interface ISport {
  sportId: number;
  name: string;
}

export interface ISportDetails extends ISport {
  enabled: boolean;
  favouritedCount: number;
}
