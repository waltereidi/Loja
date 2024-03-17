import { expect, test } from 'vitest';
import { CategoryStoreController } from "../../../src/store/Controllers/categoryStoreController";
import datasource from '../../json/categoryHeader.json' assert { type: 'json' };

const categoryStoreController =new CategoryStoreController();

test('getCategoryBar',()=>{
    const datasourceTest :Array<any> = datasource; 
    datasourceTest[0].order = 11; 
    const retorno :any = categoryStoreController.getCategoryBar(datasourceTest); 
    
    expect(retorno[0].order).toBe(2);
})