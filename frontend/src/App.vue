<template>
  <v-app>
    <v-main>
      <h1>Fill out this form </h1>
      <MyForm @added="addToComments"> </MyForm>
        <h1>Comments:</h1>
        <Commentary 
        v-for="comment in comments" 
        :key='comment.id'
        v-bind:name="comment.name"
        v-bind:commentary="comment.commentary"
        v-bind:mail="comment.eMail"> </Commentary>
      
    </v-main>
  </v-app>
</template>

<script>
import Commentary from './components/Commentary.vue';
import MyForm from './components/MyForm.vue';
export default {
  name: "App",

  components: {
    MyForm,
    Commentary,
  },

  data(){
    return {
      comments: []
    };
  },
  mounted(){
    this.$api.get('Comments').then(res => {
      this.comments = res.data;
    })
  },
  methods:{
    addToComments(value)
      {
        this.comments.push(value.data)
      }
  }
    
};
</script>

<style scoped>
h1 {
  text-align: center;
}
</style>