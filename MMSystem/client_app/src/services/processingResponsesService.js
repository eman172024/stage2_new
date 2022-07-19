import axios from 'axios';
export default {

    AddProcessingResponses(repliesInfo) {
        return axios.post(`http://172.16.0.12:82/api/Replies/AddReply`, repliesInfo)
    },

    GetProcessingResponses() {
        return axios.get(`http://172.16.0.12:82/api/Replies/GetReplies`)
    },

    DeleteResponsesService(id) {
        return axios.delete(`http://172.16.0.12:82/api/Replies/DeleteReply?replyId=${id}`);
    },

}