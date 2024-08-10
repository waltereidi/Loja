export default {
    import { ref, onMounted } from 'vue';
    import { useDi } from '@/pinia/dependencyInjection';
    
    
    const di = useDi();
    const request = di.getRequestController;
    let dataSource = ref();
    
    const editingRows = ref([]);
    
    const expandSubCategories = ref({});
    const expandSubSubCategories = ref({});
    request.getAsync("/api/Admin/Store/Categories/GetCategories")
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
}
