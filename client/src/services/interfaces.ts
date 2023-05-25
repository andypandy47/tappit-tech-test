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

export interface ISport {
  sportId: number;
  name: string;
  enabled: boolean;
}
