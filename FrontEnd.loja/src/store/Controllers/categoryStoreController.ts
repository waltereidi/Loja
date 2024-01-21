export class CategoryStoreController{

    
getCategoryBar(datasource:Array<any>) : Array<any>
{
    return datasource.filter( (x)=>  x.order<=10);
}
}