<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useDi } from '@/pinia/dependencyInjection';


const di = useDi();
const request = di.getRequestController;
let dataSource = ref();
const expandSubCategories = ref({});
const expandSubSubCategories = ref({});
request.getAsync("/api/Admin/Store/Categories/GetCategories")
    .then((result) => { dataSource.value = result })
    .catch((error) => console.log(error));

const onRowExpand = (event) => {
    console.log(event)

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
    let { newData, index } = event;
    alert()
    dataSource.value[index] = newData;
};
onMounted(() => {

});
</script>

<template>
    <div class="card">
        <DataTable v-model:expandedRows="expandSubCategories" :value="dataSource" dataKey="id" @rowExpand="onRowExpand"
            @row-edit-save="onRowEditSave" @rowCollapse="onRowCollapse" tableStyle="min-width: 60rem">
            <template #header>
                <div class="flex flex-wrap justify-content-end gap-2">
                    <Button text icon="pi pi-plus" label="Expand All" @click="expandAll" />
                    <Button text icon="pi pi-minus" label="Collapse All" @click="collapseAll" />
                </div>
            </template>
            <Column expander style="width: 5rem" />
            <Column field="name" header="Name"></Column>
            <Column header="Image">

                <template #body="dataSource">
                    <img :src="`https://primefaces.org/cdn/primevue/images/product/${dataSource.data.image}`"
                        :alt="dataSource.data.image" class="shadow-4" width="64" />
                </template>
            </Column>

            <Column field="description" header="Description"></Column>
            <Column field="order" header="Order"></Column>
            <!-- Row editor -->
            <Column :rowEditor="true" style="width: 10%; min-width: 8rem" field="name" header="edit"
                bodyStyle="text-align:center">
            </Column>
            <template #expansion="subCategories">
                <div class="p-3">
                    <h5>SubCategories</h5>
                    <DataTable v-model:expandedRows="expandSubSubCategories" :value="subCategories.data?.subCategories"
                        dataKey="id" @rowExpand="onRowExpand" @rowCollapse="onRowCollapse"
                        tableStyle="min-width: 60rem">
                        <Column expander style="width: 5rem" />
                        <Column field="subCategoriesId" header="Id" sortable></Column>
                        <Column field="name" header="Name" headerStyle="width:4rem"></Column>
                        <Column field="description" header="Description"></Column>
                        <Column field="order" header="Order"></Column>
                        <Column :rowEditor="true" field="name" header="edit" style="width: 10%; min-width: 8rem"
                            bodyStyle="text-align:center">
                        </Column>
                        <template #expansion="subSubCategories">
                            <div class="p-3">
                                <h5>SubSubCategories</h5>
                                <DataTable v-model:expandedRows="expandSubSubCategories"
                                    :value="subSubCategories.data?.subSubCategories" dataKey="id"
                                    tableStyle="min-width: 60rem">
                                    <Column field="subSubCategoriesId" header="Id" sortable></Column>
                                    <Column field="name" header="Name" headerStyle="width:4rem"></Column>
                                    <Column field="description" header="Description"></Column>
                                    <Column field="order" header="Order"></Column>
                                    <Column :rowEditor="true" style="width: 10%; min-width: 8rem"
                                        bodyStyle="text-align:center"></Column>
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