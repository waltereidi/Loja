<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useDi } from '@/pinia/dependencyInjection';


const di = useDi();
const request = di.getRequestController;
let dataSource = ref();

const editingRows = ref([]);

const expandSubCategories = ref({});
const expandSubSubCategories = ref({});
request.getAsync("/api/Admin/Categories/GetAllCategories")
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
        <DataTable v-model:expandedRows="expandSubCategories" :value="dataSource" v-model:editingRows="editingRows"
            editMode="row" dataKey="categoriesId" @row-edit-save="onRowEditSave" @rowCollapse="onRowCollapse"
            tableStyle="min-width: 60rem" @rowExpand="onRowExpand">
            <template #header>
                <div class="flex flex-wrap justify-content-end gap-2">
                    <Button text icon="pi pi-plus" label="Expand All" @click="expandAll" />
                    <Button text icon="pi pi-minus" label="Collapse All" @click="collapseAll" />
                </div>
            </template>
            <Column expander style="width: 5rem" />
            <Column field="categoriesId" header="ID"></Column>
            <Column field="name" header="Name">
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
            <!-- Row editor -->
            <Column :rowEditor="true" style="width: 10%; min-width: 8rem" bodyStyle="text-align:center">
            </Column>
            <template #expansion="subCategories">
                <div class="p-3">
                    <h5>SubCategories</h5>
                    <DataTable v-model:expandedRows="expandSubSubCategories" :value="subCategories.data?.subCategories"
                        @rowExpand="onRowExpand" @rowCollapse="onRowCollapse" tableStyle="min-width: 60rem"
                        v-model:editingRows="editingRows" editMode="row" dataKey="subCategoriesId"
                        @row-edit-save="onRowEditSave">
                        <Column expander style="width: 5rem" />
                        <Column field="subCategoriesId" header="Id" sortable></Column>
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
                        <Column :rowEditor="true" style="width: 10%; min-width: 8rem" bodyStyle="text-align:center">
                        </Column>
                        <template #expansion="subSubCategories">
                            <div class="p-3">
                                <h5>SubSubCategories</h5>
                                <DataTable v-model:expandedRows="expandSubSubCategories"
                                    :value="subSubCategories.data?.subSubCategories" tableStyle="min-width: 60rem"
                                    v-model:editingRows="editingRows" editMode="row" dataKey="subSubCategoriesId"
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
                    </DataTable>
                </div>
            </template>
        </DataTable>
    </div>
</template>

<style scoped></style>