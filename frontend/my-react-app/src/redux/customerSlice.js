import { createSlice } from "@reduxjs/toolkit";
import { fetchDataAsyncAction } from "./thunk";

const customerSlice=createSlice({
    name:"customer",
    initialState: {
        customerList: [],
        // loading: false,
        // error: false
    },
    reducers:{},
    extraReducers:(builder) => {
        builder
            .addCase(fetchDataAsyncAction.pending, (state) => {
                // state.loading = true;
                state.customerList = [];
                // state.selectedList=[];
                // state.error = false;
            })
            .addCase(fetchDataAsyncAction.fulfilled, (state, action) => {
               state.customerList = action.payload;
            //    state.loading = false;
            //    state.error = false;
            })
            .addCase(fetchDataAsyncAction.rejected, (state) => {
                // state.loading = false;
                // state.error = true;
            })
    }
})
export default customerSlice.reducer