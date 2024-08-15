<style scoped></style>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useDi } from '@/pinia/dependencyInjection';
import { FilterMatchMode } from '@primevue/core/api';

const di = useDi();
const request = di.getRequestController;
let dataSource = ref();
let filters = {
        name: { value: null, matchMode: FilterMatchMode.STARTS_WITH },
      };
      
const editingRows = ref([]);

const expandSubCategories = ref({});
const expandSubSubCategories = ref({});
request.send( 'getAsync' ,"/api/Admin/Categories/GetAllCategories")
    .then((result) => { dataSource.value = result })
    .catch((error) => console.log(error));

const onRowExpand = (event) => {

};
const onRowCollapse = (event) => {

};
const expandAll = () => {
    expandSubCategories.value = dataSource.value.reduce((acc, p) => (acc[p.id] = true) && acc, {});
};
const collapseAll = () => {
    expandSubCategories.value = null;
};
const formatCurrency = (value) => {
    return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
};
const onRowEditSave = (event) => {
    console.log(event)
};
onMounted(() => {

});

</script>



<template>
    <div class="card">
        <DataTable  
        v-model:expandedRows="expandSubCategories" 
        v-model:editingRows="editingRows"
        :value="dataSource" 
        @rowExpand="onRowExpand"
        @row-edit-save="onRowEditSave" 
        @rowCollapse="onRowCollapse"
        editMode="row" 
        dataKey="categoriesId" 
        tableStyle="min-width: 60rem"
        paginator 
        :rows="5" 
        paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
        :rowsPerPageOptions="[5, 10, 20, 50]"
        filterDisplay="row"
        v-model:filters="filters"
        :globalFilterFields="['name']"
        >
            <!-- Table Header Expand and collapse buttons on top-->
            <template #header>
                <div class="flex flex-wrap justify-content-end gap-2">
                    <Button text icon="pi pi-plus" label="Expand All" @click="expandAll" />
                    <Button text icon="pi pi-minus" label="Collapse All" @click="collapseAll" />
                </div>
            </template>
            <!-- End of table headers -->

            <!-- Start of table Categories -->
            <Column expander style="width: 5rem" />
            
            <Column field="categoriesId" header="ID"></Column>
            
            <Column  field="name" header="Name" style="min-width: 12rem">
                            <template #body="{ data }">
                                {{ data.name }}
                            </template>

                            <template #filter="{ filterModel, filterCallback }">
                                <InputText
                                    v-model="filterModel.value"
                                    type="text"
                                    @input="filterCallback()"
                                    placeholder="Search by name"
                                />
                            </template>
            </Column>

            <Column field="description" header="Description">
                <template #editor="{ data, field }">
                    <InputText v-model="data[field]" />
                </template>
            </Column>
            
            <Column field="order" header="Order"></Column>
            
            <Column :rowEditor="true" style="width: 10%; min-width: 8rem" bodyStyle="text-align:center"></Column><!-- Row editor -->
            <!-- End of table columns -->

             <!-- Start of Table SubCategories inside of categories -->
            <template #expansion="subCategories">
                <div class="p-3">
                    <h5>SubCategories</h5>
                    <DataTable 
                        v-model:expandedRows="expandSubSubCategories" 
                        :value="subCategories.data?.getSubCategories"
                        @rowExpand="onRowExpand" 
                        @rowCollapse="onRowCollapse" 
                        tableStyle="min-width: 60rem"
                        v-model:editingRows="editingRows" 
                        editMode="row" 
                        dataKey="subCategoriesId"
                        @row-edit-save="onRowEditSave"
                        paginator 
                        :rows="5" 
                        :rowsPerPageOptions="[5, 10, 20, 50]">

                        <Column expander style="width: 5rem" />

                        <Column field="subCategoriesId" header="Id" sortable></Column>

                        <Column field="name" header="Name" headerStyle="width:4rem">
                        </Column>

                        <Column field="description" header="Description">
                            <template #editor="{ data, field }">
                                <InputText v-model="data[field]" />
                            </template>
                        </Column>

                        <Column field="order" header="Order"></Column>

                        <Column :rowEditor="true" style="width: 10%; min-width: 8rem" bodyStyle="text-align:center"></Column>

                        <!-- Start of subsubCategories -->
                        <template #expansion="subSubCategories">
                            <div class="p-3">
                                <h5>SubSubCategories</h5>
                                
                                <DataTable 
                                    v-model:expandedRows="expandSubSubCategories"
                                    :value="subSubCategories.data?.getSubSubCategories" 
                                    tableStyle="min-width: 60rem"
                                    v-model:editingRows="editingRows" 
                                    editMode="row" 
                                    dataKey="subSubCategoriesId"
                                    @row-edit-save="onRowEditSave">

                                    <Column field="subSubCategoriesId" header="Id" sortable></Column>

                                    <Column field="name" header="Name" headerStyle="width:4rem">
                                        <template #editor="{ data, field }">
                                            <InputText v-model="data[field]" />
                                        </template>
                                    </Column>

                                    <Column field="description" header="Description">
                                        <template #editor="{ data, field }">
                                            <InputText v-model="data[field]" />
                                        </template>
                                    </Column>

                                    <Column field="order" header="Order"></Column>

                                    <Column :rowEditor="true" style="width: 10%; min-width: 8rem"
                                        bodyStyle="text-align:center">
                                    </Column>

                                </DataTable>
                                
                            </div>
                        </template>
                        <!-- End of subsubCategories -->
                    </DataTable>
                </div>
            </template>
            <!-- End of SubCategories Table -->
        </DataTable>
    </div>
</template>
