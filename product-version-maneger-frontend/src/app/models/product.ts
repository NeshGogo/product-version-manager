export interface Product{
  id?: number;
  name: string;
  brand: string;
  price: number;
  seller: string;
  date?: Date;
  version?:number;
  productVersions?: Product[]
}