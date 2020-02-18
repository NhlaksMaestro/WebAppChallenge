interface IEmployee {
  id?: number;
  managerId?: number;
  name: string;
  surname: string;
  inverseManager?: Array<IEmployee>;
  manager?: IEmployee;
}
