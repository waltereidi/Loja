<script lang="ts">
export default {

}

// const onRowExpand = (event) => {
//     toast.add({ severity: 'info', summary: 'Product Expanded', detail: event.data.name, life: 3000 });
// };
// const onRowCollapse = (event) => {
//     toast.add({ severity: 'success', summary: 'Product Collapsed', detail: event.data.name, life: 3000 });
// };
// const expandAll = () => {
//     expandedRows.value = products.value.reduce((acc, p) => (acc[p.id] = true) && acc, {});
// };
// const collapseAll = () => {
//     expandedRows.value = null;
// };
// const formatCurrency = (value) => {
//     return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
// };

</script>

<template>
    <div class="card">
        <DataTable v-model:expandedRows="expandedRows" :value="dataSource" dataKey="id" @rowExpand="onRowExpand"
            @rowCollapse="onRowCollapse" tableStyle="min-width: 60rem">
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

            <template #expansion="dataSource">
                <div class="p-3">
                    <h5>SubCategories</h5>
                    <DataTable :value="dataSource.subCateories">
                        <Column field="ID_SubCategories" header="Id" sortable></Column>
                        <Column field="name" header="Name" headerStyle="width:4rem"></Column>
                        <Column field="description" header="Description"></Column>
                        <Column field="order" header="Order"></Column>

                    </DataTable>
                </div>
            </template>
        </DataTable>
        <Toast />
    </div>
</template>

<style scoped></style>