import axios from 'axios';
export default {

    AddProcessingResponses(repliesInfo) {
        return axios.post(`/api/Replies/AddReply`, repliesInfo)
    },

    GetProcessingResponses() {
        return axios.get(`/api/Replies/GetReplies`)
    },

    DeleteResponsesService(id) {
        return axios.delete(`/api/Replies/DeleteReply?replyId=${id}`);
    },

}