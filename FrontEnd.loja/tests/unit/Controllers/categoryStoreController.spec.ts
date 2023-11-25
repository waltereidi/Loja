import { expect, test } from 'vitest';
import { CategoryStoreController } from "../../../src/store/Controllers/categoryStoreController";

const datasource = require('../../json/categoryHeader.json');
const categoryStoreController =new CategoryStoreController();

test('getCategoryBar',()=>{
    let datasourceTest :Array<any> = datasource; 
    datasourceTest[0].order = 11; 
    const retorno :any = categoryStoreController.getCategoryBar(datasourceTest); 
    
    expect(retorno[0].order).toBe(2);
})